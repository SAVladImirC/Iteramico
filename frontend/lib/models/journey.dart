import 'package:frontend/models/city.dart';
import 'package:frontend/models/user.dart';

class Journey {
  final int id;
  final String name;
  final User creator;
  final City to;

  Journey(
      {required this.id,
      required this.name,
      required this.creator,
      required this.to});

  factory Journey.fromJson(Map<String, dynamic> json) {
    return Journey(
      id: json['id'],
      name: json['name'],
      creator: User.fromJson(json['creator']),
      to: City.fromJson(json['to']),
    );
  }
}
