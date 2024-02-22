class ReminderCreateRequest {
  final String note;
  final DateTime deadline;
  final int creatorId;
  final int journeyId;
  final int forId;

  ReminderCreateRequest(
      {required this.note,
      required this.deadline,
      required this.creatorId,
      required this.journeyId,
      required this.forId});

  Map<String, dynamic> toJson() {
    return {
      'note': note,
      'deadline': deadline.toIso8601String(),
      'creatorId': creatorId,
      'journeyId': journeyId,
      'forId': forId,
    };
  }
}
