class OverallStatus {
  String? year;
  int? totalContest;
  int? totalGroup;
  int? totalMembers;
  int? totalMinutes;

  OverallStatus(
      {this.year,
      this.totalContest,
      this.totalGroup,
      this.totalMembers,
      this.totalMinutes});

  OverallStatus.fromJson(Map<String, dynamic> json) {
    year = json['year'];
    totalContest = json['totalContest'];
    totalGroup = json['totalGroup'];
    totalMembers = json['totalMembers'];
    totalMinutes = json['totalMinutes'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['year'] = this.year;
    data['totalContest'] = this.totalContest;
    data['totalGroup'] = this.totalGroup;
    data['totalMembers'] = this.totalMembers;
    data['totalMinutes'] = this.totalMinutes;
    return data;
  }
}
