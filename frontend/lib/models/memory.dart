import 'package:frontend/models/user.dart';

class Memory {
  final int id;
  final String name;
  final String imageBase64;
  final DateTime postedOn;
  final User creator;

  Memory(
      {required this.id,
      required this.name,
      required this.imageBase64,
      required this.postedOn,
      required this.creator});

  factory Memory.fromJson(Map<String, dynamic> json) {
    return Memory(
        id: json['id'],
        name: json['name'],
        imageBase64: json['imageBase64'],
        postedOn: DateTime.parse(json['postedOn']),
        creator: User.fromJson(json['creator']));
  }
}
