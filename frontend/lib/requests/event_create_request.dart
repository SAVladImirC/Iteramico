class EventCreateRequest {
  final String name;
  final int creatorId;
  final int journeyId;
  final DateTime from;
  final DateTime to;

  EventCreateRequest(
      {required this.name,
      required this.creatorId,
      required this.journeyId,
      required this.from,
      required this.to});

  Map<String, dynamic> toJson() {
    return {
      'name': name,
      'from': from.toIso8601String(),
      'to': to.toIso8601String(),
      'creatorId': creatorId,
      'journeyId': journeyId,
    };
  }
}
