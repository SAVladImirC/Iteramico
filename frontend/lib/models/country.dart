class Country {
  final int id;
  final String name;
  final String localName;
  final String countryCode;

  Country(
      {required this.id,
      required this.name,
      required this.localName,
      required this.countryCode});

  factory Country.fromJson(Map<String, dynamic> json) {
    return Country(
      id: json['id'],
      name: json['name'],
      localName: json['localName'],
      countryCode: json['countryCode'],
    );
  }
}
