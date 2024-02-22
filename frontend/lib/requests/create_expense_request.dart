class ExpenseCreateRequest {
  final double price;
  final String currency;
  final String description;
  final int creatorId;
  final int journeyId;
  final List<int> participants;

  ExpenseCreateRequest(
      {required this.price,
      required this.currency,
      required this.description,
      required this.creatorId,
      required this.journeyId,
      required this.participants});

  Map<String, dynamic> toJson() {
    return {
      'price': price,
      'creatorId': creatorId,
      'journeyId': journeyId,
      'currency': currency,
      'description': description,
      'participants': participants
    };
  }
}
