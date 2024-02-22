import 'package:frontend/models/user.dart';

class Reminder {
  final int id;
  final String note;
  final DateTime deadline;
  final User refersTo;
  final User creator;

  Reminder(
      {required this.id,
      required this.note,
      required this.deadline,
      required this.refersTo,
      required this.creator});

  factory Reminder.fromJson(Map<String, dynamic> json) {
    return Reminder(
        id: json['id'],
        note: json['note'],
        deadline: DateTime.parse(json['deadline']),
        creator: User.fromJson(json['creator']),
        refersTo: User.fromJson(json['for']));
  }
}
