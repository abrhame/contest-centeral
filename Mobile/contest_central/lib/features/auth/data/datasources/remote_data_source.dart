import 'dart:convert';
import 'dart:developer';
import 'dart:io';

import 'package:contest_central/features/auth/data/model/user.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

import 'data_source_api.dart';

class UserApiDataSource implements UserRemoteDataSource {
  final String baseUrl;
  UserApiDataSource({required this.baseUrl});

  Future<Map<String, dynamic>> _fetchData(
      String endpoint, Map<String, dynamic> data) async {
    log("fetching: $baseUrl/$endpoint");
    try {
      log("My data: $data");
      final response = await http.post(
        Uri.parse('$baseUrl/$endpoint'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode(data),
      );

      final responseData = json.decode(response.body) as Map<String, dynamic>;
      if (response.statusCode == 200 && responseData['success'] == true) {
        log("fetched: $responseData");

        // Check if the response has a 'token' key
        if (responseData.containsKey('token')) {
          final token = responseData['token'] as String;

          // Store token in SharedPreferences
          final prefs = await SharedPreferences.getInstance();
          prefs.setString('auth_token', token);

          log("token is saved: $token");
        }

        return responseData['data'];
      } else {
        log("error: $responseData");
        final errorMessage =
            responseData['message'] as String? ?? 'Unknown error';
        throw Exception(errorMessage);
      }
    } catch (e) {
      log("error:: $e");
      throw Exception('An error occurred: $e');
    }
  }

  @override
  Future<void> delUserByID(Map<String, dynamic> userData) {
    // TODO: implement delUserByID
    throw UnimplementedError();
  }

  @override
  Future<void> forgetPassword(String email) {
    // TODO: implement forgetPassword
    throw UnimplementedError();
  }

  @override
  Future<List<User>> getAllUser() {
    // TODO: implement getAllUser
    throw UnimplementedError();
  }

  @override
  Future<User> getUserByID() {
    // TODO: implement getUserByID
    throw UnimplementedError();
  }

  @override
  Future<Map<String, dynamic>> loginUser(Map<String, dynamic> loginData) async {
    final url = Uri.parse('$baseUrl/api/Auth/login');
    print("==========> Request sent! $baseUrl/api/Auth/login");
    print("==========> Data: $loginData");

    final response = await http.post(
      url,
      headers: {
        'accept': 'text/plain',
        'Content-Type': 'application/json',
      },
      body: jsonEncode(loginData),
    );

    if (response.statusCode == 200) {
      final Map<String, dynamic> userData = jsonDecode(response.body);
      print("==========> User successfully logged in <==========");
      print("User data: $userData");

      await saveUserInfo(userData);

      return userData;
    } else {
      print("==========> User failed to login:${response.body} <==========");
      throw Exception('Something went wrong!');
    }
  }

  Future<void> saveUserInfo(Map<String, dynamic> userData) async {
    final prefs = await SharedPreferences.getInstance();
    prefs.setString('token', userData['token']);
    prefs.setString('userId', userData['id']);
    prefs.setString('userName', userData['userName']);
    prefs.setString('email', userData['email']);
    prefs.setString('firstName', userData['firstName']);
    prefs.setString('lastName', userData['lastName']);
    print("==========> Token Saved! <==========");
  }

  @override
  Future<void> putUserByID(Map<String, dynamic> userData) {
    // TODO: implement putUserByID
    throw UnimplementedError();
  }

  @override
  Future<void> registerUser(Map<String, dynamic> userData) {
    // TODO: implement registerUser
    throw UnimplementedError();
  }

  @override
  Future<void> resetPasswordUser(Map<String, dynamic> resetPasswordData) {
    // TODO: implement resetPasswordUser
    throw UnimplementedError();
  }

  @override
  Future<User> updateProfilePhoto(File userData) {
    // TODO: implement updateProfilePhoto
    throw UnimplementedError();
  }
}
