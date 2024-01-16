class Group {
  String? name;
  String? abbreviation;
  String? generation;
  String? year;
  String? locationId;
  Null? location;
  String? id;
  String? createdAt;
  String? modifiedAt;

  Group(
      {this.name,
      this.abbreviation,
      this.generation,
      this.year,
      this.locationId,
      this.location,
      this.id,
      this.createdAt,
      this.modifiedAt});

  Group.fromJson(Map<String, dynamic> json) {
    name = json['name'];
    abbreviation = json['abbreviation'];
    generation = json['generation'];
    year = json['year'];
    locationId = json['locationId'];
    location = json['location'];
    id = json['id'];
    createdAt = json['createdAt'];
    modifiedAt = json['modifiedAt'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['name'] = this.name;
    data['abbreviation'] = this.abbreviation;
    data['generation'] = this.generation;
    data['year'] = this.year;
    data['locationId'] = this.locationId;
    data['location'] = this.location;
    data['id'] = this.id;
    data['createdAt'] = this.createdAt;
    data['modifiedAt'] = this.modifiedAt;
    return data;
  }
}
