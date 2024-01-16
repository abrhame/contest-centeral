abstract class RemoteDataSourceApi {
  Future<Map<String, dynamic>> overAllStatus(Map<String, dynamic> data);
  Future<List<Map<String, dynamic>>> getRankedGroups();
  Future<List<Map<String, dynamic>>> getContestsByFilter();
}
