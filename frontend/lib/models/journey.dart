import 'package:frontend/models/city.dart';
import 'package:frontend/models/event.dart';
import 'package:frontend/models/expense.dart';
import 'package:frontend/models/reminder.dart';
import 'package:frontend/models/user.dart';

class Journey {
  final int id;
  final String name;
  final User creator;
  final City to;
  final List<Event> events;
  final List<Reminder> reminders;
  final List<Expense> expenses;

  Journey(
      {required this.id,
      required this.name,
      required this.creator,
      required this.to,
      required this.events,
      required this.reminders,
      required this.expenses});

  factory Journey.fromJson(Map<String, dynamic> json) {
    return Journey(
        id: json['id'],
        name: json['name'],
        creator: User.fromJson(json['creator']),
        to: City.fromJson(json['to']),
        events:
            json['events'].map<Event>((json) => Event.fromJson(json)).toList(),
        reminders: json['reminders']
            .map<Reminder>((json) => Reminder.fromJson(json))
            .toList(),
        expenses: json['expenses']
            .map<Expense>((json) => Expense.fromJson(json))
            .toList());
  }
}
