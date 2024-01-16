import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

import 'data_source_api.dart';

class EducationSquadApiDataSource implements RemoteDataSourceApi {
  final String baseUrl;
  EducationSquadApiDataSource({required this.baseUrl});

  // get token from shared preferences function
  Future<String> getToken() async {
    final prefs = await SharedPreferences.getInstance();
    final token = prefs.getString('token');
    return token!;
  }

  @override
  Future<Map<String, dynamic>> overAllStatus(Map<String, dynamic> data) async {
    final url = Uri.parse('$baseUrl/api/OverallStatus/overall-status');
    print(
        "==========> Request sent! $baseUrl/api/OverallStatus/overall-status");

    final response = await http.get(
      url,
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json',
      },
      //  body: jsonEncode(data),
    );

    if (response.statusCode == 200) {
      final Map<String, dynamic> responseData = jsonDecode(response.body);
      print("==========> Dashboard successfully <==========");
      print("Data: $responseData");

      return responseData;
    } else {
      print(
          "==========> Dashboard failed to load:${response.body} <==========");
      throw Exception('Something went wrong!');
    }
  }

  @override
  Future<List<Map<String, dynamic>>> getRankedGroups() async {
    final url = Uri.parse('$baseUrl/api/Group/GetRankedGroups');
    print("==========> Request sent! $baseUrl/api/Group/GetRankedGroups");

    final response = await http.get(
      url,
      headers: {
        'accept': 'accept: text/plain',
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ${await getToken()}',
      },
    );

    if (response.statusCode == 200) {
      final List<dynamic> responseData = jsonDecode(response.body);

      List<Map<String, dynamic>> rankedGroups =
          List<Map<String, dynamic>>.from(responseData);

      print("==========> RankedGroups successfully <==========");
      return rankedGroups;
    } else {
      print(
          "==========> RankedGroups failed to load:${response.body} <==========");
      throw Exception('Something went wrong!');
    }
  }

  @override
  Future<List<Map<String, dynamic>>> getContestsByFilter() async {
    final url = Uri.parse('$baseUrl/api/Contests/GetContestsByFilter');
    print(
        "==========> Request sent! $baseUrl/api/Contests/GetContestsByFilter");

    final response = await http.get(
      url,
      headers: {
        'accept': 'accept: text/plain',
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ${await getToken()}',
      },
    );

    if (response.statusCode == 200) {
      final responseData = jsonDecode(response.body) as Map<String, dynamic>;

      List<Map<String, dynamic>> rankedGroups =
          List<Map<String, dynamic>>.from(responseData['contestsList']);

      print("==========> getContestsByFilter successfully <==========");
      return rankedGroups;
    } else {
      print(
          "==========> getContestsByFilter failed to load:${response.body} <==========");
      throw Exception('Something went wrong!');
    }
  }
}
