import 'package:frontend/models/user.dart';

class Event {
  final int id;
  final String name;
  final DateTime from;
  final DateTime to;
  final User creator;

  Event(
      {required this.id,
      required this.name,
      required this.from,
      required this.to,
      required this.creator});

  factory Event.fromJson(Map<String, dynamic> json) {
    return Event(
        id: json['id'],
        name: json['name'],
        from: DateTime.parse(json['from']),
        to: DateTime.parse(json['to']),
        creator: User.fromJson(json['creator']));
  }
}
