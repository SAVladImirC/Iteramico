import 'package:frontend/models/journey.dart';

class JourneyParticipation {
  final DateTime joinedOn;
  final int userId;
  final Journey journey;

  JourneyParticipation(
      {required this.joinedOn, required this.userId, required this.journey});

  factory JourneyParticipation.fromJson(Map<String, dynamic> json) {
    return JourneyParticipation(
      joinedOn: DateTime.parse(json['joinedOn']),
      userId: json['userId'],
      journey: Journey.fromJson(json['journey']),
    );
  }
}
