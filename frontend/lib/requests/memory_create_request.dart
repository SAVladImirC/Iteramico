class MemoryCreateRequest {
  final String base64image;
  final String name;
  final int creatorId;
  final int journeyId;

  MemoryCreateRequest(
      {required this.base64image,
      required this.name,
      required this.creatorId,
      required this.journeyId});

  Map<String, dynamic> toJson() {
    return {
      'base64image': base64image,
      'name': name,
      'creatorId': creatorId,
      'journeyId': journeyId,
    };
  }
}
