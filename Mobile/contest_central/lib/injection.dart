import 'package:get_it/get_it.dart';
import 'package:http/http.dart' as http;
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '/core/platform/network_info.dart';

final sl = GetIt.instance;

Future<void> init() async {
  final sharedPreference = await SharedPreferences.getInstance();
  sl.registerSingleton<SharedPreferences>(sharedPreference);

  // Register network info
  sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));
  sl.registerLazySingleton(() => http.Client());
  sl.registerLazySingleton(() => InternetConnectionChecker());

  // // register bloc
  // sl.registerFactory(() => UserBloc(
  //       registerUser: sl(),
  //       loginUser: sl(),
  //       getUser: sl(),
  //       updateProfilePhoto: sl(),
  //     ));

//   // Register use cases
//   sl.registerFactory(() => RegisterUserUseCase(sl()));
//   sl.registerFactory(() => LoginUserUseCase(sl()));
//   sl.registerFactory(() => GetUserUseCase(sl()));
//   sl.registerFactory(() => ChangeProfileUseCase(sl()));

//   // register ArticleRepositoryImpl
//   sl.registerLazySingleton<ArticleRepository>(() =>
//       ArticleRepositoryImpl(remoteDataSource: sl(), localDataSource: sl()));

//   //RemoteDataSource
//   sl.registerLazySingleton<BlogRemoteDataSource>(() =>
//       RemoteDataSource(baseUrl: 'https://blog-api-4z3m.onrender.com/api/v1'));
//   // Register BlogLocalDataSource
//   sl.registerLazySingleton<BlogLocalDataSource>(
//       () => BlogLocalDataSourceImp(sharedPreferences: sl()));
//   sl.registerLazySingleton<UserApiDataSource>(() =>
//       UserApiDataSource(baseUrl: 'https://blog-api-4z3m.onrender.com/api/v1'));
//   // UserLocalDataSourceImpl
//   sl.registerLazySingleton<UserLocalDataSource>(
//       () => UserLocalDataSourceImpl(sharedPreferences: sl()));
//   // Register repositories
//   sl.registerLazySingleton<UserRepository>(
//       () => UserRepositoryImpl(remoteDataSource: sl(), localDataSource: sl()));

// //'https://blog-api-4z3m.onrender.com'
}
