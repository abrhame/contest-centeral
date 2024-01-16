// class Contest {
//   String? contestGlobalId;
//   String? contestUrl;
//   String? name;
//   String? type;
//   int? durationSeconds;
//   int? startTimeSeconds;
//   int? relativeTimeSeconds;
//   String? preparedBy;
//   String? websiteUrl;
//   String? description;
//   String? difficulty;
//   String? kind;
//   String? season;
//   String? status;
//   int? participantsNumber;
//   int? questionsNumber;
//   List<ContestGroups>? contestGroups;
//   List<Questions>? questions;
//   List<UserContestResults>? userContestResults;
//   String? id;
//   String? createdAt;
//   String? modifiedAt;

//   Contest(
//       {this.contestGlobalId,
//       this.contestUrl,
//       this.name,
//       this.type,
//       this.durationSeconds,
//       this.startTimeSeconds,
//       this.relativeTimeSeconds,
//       this.preparedBy,
//       this.websiteUrl,
//       this.description,
//       this.difficulty,
//       this.kind,
//       this.season,
//       this.status,
//       this.participantsNumber,
//       this.questionsNumber,
//       this.contestGroups,
//       this.questions,
//       this.userContestResults,
//       this.id,
//       this.createdAt,
//       this.modifiedAt});

//   Contest.fromJson(Map<String, dynamic> json) {
//     contestGlobalId = json['contestGlobalId'];
//     contestUrl = json['contestUrl'];
//     name = json['name'];
//     type = json['type'];
//     durationSeconds = json['durationSeconds'];
//     startTimeSeconds = json['startTimeSeconds'];
//     relativeTimeSeconds = json['relativeTimeSeconds'];
//     preparedBy = json['preparedBy'];
//     websiteUrl = json['websiteUrl'];
//     description = json['description'];
//     difficulty = json['difficulty'];
//     kind = json['kind'];
//     season = json['season'];
//     status = json['status'];
//     participantsNumber = json['participantsNumber'];
//     questionsNumber = json['questionsNumber'];
//     if (json['contestGroups'] != null) {
//       contestGroups = <ContestGroups>[];
//       json['contestGroups'].forEach((v) {
//         contestGroups!.add(new ContestGroups.fromJson(v));
//       });
//     }
//     if (json['questions'] != null) {
//       questions = <Questions>[];
//       json['questions'].forEach((v) {
//         questions!.add(new Questions.fromJson(v));
//       });
//     }
//     if (json['userContestResults'] != null) {
//       userContestResults = <UserContestResults>[];
//       json['userContestResults'].forEach((v) {
//         userContestResults!.add(new UserContestResults.fromJson(v));
//       });
//     }
//     id = json['id'];
//     createdAt = json['createdAt'];
//     modifiedAt = json['modifiedAt'];
//   }

//   Map<String, dynamic> toJson() {
//     final Map<String, dynamic> data = new Map<String, dynamic>();
//     data['contestGlobalId'] = contestGlobalId;
//     data['contestUrl'] = contestUrl;
//     data['name'] = name;
//     data['type'] = type;
//     data['durationSeconds'] = durationSeconds;
//     data['startTimeSeconds'] = startTimeSeconds;
//     data['relativeTimeSeconds'] = relativeTimeSeconds;
//     data['preparedBy'] = preparedBy;
//     data['websiteUrl'] = websiteUrl;
//     data['description'] = description;
//     data['difficulty'] = difficulty;
//     data['kind'] = kind;
//     data['season'] = season;
//     data['status'] = status;
//     data['participantsNumber'] = participantsNumber;
//     data['questionsNumber'] = questionsNumber;
//     if (contestGroups != null) {
//       data['contestGroups'] =
//           contestGroups!.map((v) => v.toJson()).toList();
//     }
//     if (questions != null) {
//       data['questions'] = questions!.map((v) => v.toJson()).toList();
//     }
//     if (userContestResults != null) {
//       data['userContestResults'] =
//           userContestResults!.map((v) => v.toJson()).toList();
//     }
//     data['id'] = id;
//     data['createdAt'] = createdAt;
//     data['modifiedAt'] = modifiedAt;
//     return data;
//   }
// }

// class ContestGroups {
//   String? groupId;
//   Group? group;

//   ContestGroups({this.groupId, this.group});

//   ContestGroups.fromJson(Map<String, dynamic> json) {
//     groupId = json['groupId'];
//     group = json['group'] != null ? new Group.fromJson(json['group']) : null;
//   }

//   Map<String, dynamic> toJson() {
//     final Map<String, dynamic> data = new Map<String, dynamic>();
//     data['groupId'] = groupId;
//     if (group != null) {
//       data['group'] = group!.toJson();
//     }
//     return data;
//   }
// }

// class Group {
//   String? name;
//   String? abbreviation;
//   String? locationId;
//   Location? location;
//   String? generation;
//   String? year;

//   Group(
//       {this.name,
//       this.abbreviation,
//       this.locationId,
//       this.location,
//       this.generation,
//       this.year});

//   Group.fromJson(Map<String, dynamic> json) {
//     name = json['name'];
//     abbreviation = json['abbreviation'];
//     locationId = json['locationId'];
//     location = json['location'] != null
//         ? new Location.fromJson(json['location'])
//         : null;
//     generation = json['generation'];
//     year = json['year'];
//   }

//   Map<String, dynamic> toJson() {
//     final Map<String, dynamic> data = new Map<String, dynamic>();
//     data['name'] = name;
//     data['abbreviation'] = abbreviation;
//     data['locationId'] = locationId;
//     if (location != null) {
//       data['location'] = location!.toJson();
//     }
//     data['generation'] = generation;
//     data['year'] = year;
//     return data;
//   }
// }

// class Location {
//   String? location;
//   String? country;
//   String? id;
//   String? createdAt;
//   String? modifiedAt;

//   Location(
//       {this.location, this.country, this.id, this.createdAt, this.modifiedAt});

//   Location.fromJson(Map<String, dynamic> json) {
//     location = json['location'];
//     country = json['country'];
//     id = json['id'];
//     createdAt = json['createdAt'];
//     modifiedAt = json['modifiedAt'];
//   }

//   Map<String, dynamic> toJson() {
//     final Map<String, dynamic> data = new Map<String, dynamic>();
//     data['location'] = location;
//     data['country'] = country;
//     data['id'] = id;
//     data['createdAt'] = createdAt;
//     data['modifiedAt'] = modifiedAt;
//     return data;
//   }
// }

// class Questions {
//   String? contestId;
//   String? globalQuestionUrl;
//   String? name;
//   String? index;
//   List<Null>? userQuestionResults;
//   List<Null>? teamQuestionResults;
//   String? id;
//   String? createdAt;
//   String? modifiedAt;

//   Questions(
//       {this.contestId,
//       this.globalQuestionUrl,
//       this.name,
//       this.index,
//       this.userQuestionResults,
//       this.teamQuestionResults,
//       this.id,
//       this.createdAt,
//       this.modifiedAt});

//   Questions.fromJson(Map<String, dynamic> json) {
//     contestId = json['contestId'];
//     globalQuestionUrl = json['globalQuestionUrl'];
//     name = json['name'];
//     index = json['index'];
//     if (json['userQuestionResults'] != null) {
//       userQuestionResults = <Null>[];
//       json['userQuestionResults'].forEach((v) {
//         userQuestionResults!.add(new Null.fromJson(v));
//       });
//     }
//     if (json['teamQuestionResults'] != null) {
//       teamQuestionResults = <Null>[];
//       json['teamQuestionResults'].forEach((v) {
//         teamQuestionResults!.add(new Null.fromJson(v));
//       });
//     }
//     id = json['id'];
//     createdAt = json['createdAt'];
//     modifiedAt = json['modifiedAt'];
//   }

//   Map<String, dynamic> toJson() {
//     final Map<String, dynamic> data = new Map<String, dynamic>();
//     data['contestId'] = contestId;
//     data['globalQuestionUrl'] = globalQuestionUrl;
//     data['name'] = name;
//     data['index'] = index;
//     if (userQuestionResults != null) {
//       data['userQuestionResults'] =
//           userQuestionResults!.map((v) => v.toJson()).toList();
//     }
//     if (teamQuestionResults != null) {
//       data['teamQuestionResults'] =
//           teamQuestionResults!.map((v) => v.toJson()).toList();
//     }
//     data['id'] = id;
//     data['createdAt'] = createdAt;
//     data['modifiedAt'] = modifiedAt;
//     return data;
//   }
// }

// class UserContestResults {
//   String? userId;
//   Null? user;
//   String? contestId;
//   int? points;
//   int? rank;
//   int? penalty;
//   int? successfulHackCount;
//   int? unsuccessfulHackCount;
//   bool? isVirtual;
//   String? id;
//   String? createdAt;
//   String? modifiedAt;

//   UserContestResults(
//       {this.userId,
//       this.user,
//       this.contestId,
//       this.points,
//       this.rank,
//       this.penalty,
//       this.successfulHackCount,
//       this.unsuccessfulHackCount,
//       this.isVirtual,
//       this.id,
//       this.createdAt,
//       this.modifiedAt});

//   UserContestResults.fromJson(Map<String, dynamic> json) {
//     userId = json['userId'];
//     user = json['user'];
//     contestId = json['contestId'];
//     points = json['points'];
//     rank = json['rank'];
//     penalty = json['penalty'];
//     successfulHackCount = json['successfulHackCount'];
//     unsuccessfulHackCount = json['unsuccessfulHackCount'];
//     isVirtual = json['isVirtual'];
//     id = json['id'];
//     createdAt = json['createdAt'];
//     modifiedAt = json['modifiedAt'];
//   }

//   Map<String, dynamic> toJson() {
//     final Map<String, dynamic> data = new Map<String, dynamic>();
//     data['userId'] = userId;
//     data['user'] = user;
//     data['contestId'] = contestId;
//     data['points'] = points;
//     data['rank'] = rank;
//     data['penalty'] = penalty;
//     data['successfulHackCount'] = successfulHackCount;
//     data['unsuccessfulHackCount'] = unsuccessfulHackCount;
//     data['isVirtual'] = isVirtual;
//     data['id'] = id;
//     data['createdAt'] = createdAt;
//     data['modifiedAt'] = modifiedAt;
//     return data;
//   }
// }
