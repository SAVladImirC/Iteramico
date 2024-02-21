import 'package:frontend/models/country.dart';

class City {
  final int id;
  final String localName;
  final String name;
  final Country country;

  City(
      {required this.id,
      required this.localName,
      required this.name,
      required this.country});

  factory City.fromJson(Map<String, dynamic> json) {
    return City(
      id: json['id'],
      name: json['name'],
      localName: json['localName'],
      country: Country.fromJson(json['country']),
    );
  }
}
