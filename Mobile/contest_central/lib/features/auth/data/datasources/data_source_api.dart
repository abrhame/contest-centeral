import 'dart:io';

import '../model/user.dart';

abstract class UserRemoteDataSource {
  
  Future<void> registerUser(Map<String, dynamic> userData);
  Future<Map<String, dynamic>> loginUser(Map<String, dynamic> loginData);
  Future<void> forgetPassword(String email);
  Future<void> resetPasswordUser(Map<String, dynamic> resetPasswordData);
  Future<List<User>> getAllUser();
  Future<User> getUserByID();
  Future<void> putUserByID(Map<String, dynamic> userData);
  Future<void> delUserByID(Map<String, dynamic> userData);
  Future<User> updateProfilePhoto(File userData);
}

abstract class UserLocalDataSource {
  Future<void> saveUserData(User user);
  Future<User?> getUserData();
  Future<void> clearUserData();
}
