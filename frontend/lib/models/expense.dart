import 'package:frontend/models/user.dart';

class Expense {
  final int id;
  final double price;
  final String currency;
  final String description;
  final User creator;

  Expense(
      {required this.id,
      required this.price,
      required this.currency,
      required this.description,
      required this.creator});

  factory Expense.fromJson(Map<String, dynamic> json) {
    return Expense(
        id: json['id'],
        price: json['price'],
        currency: json['currency'],
        description: json['description'],
        creator: User.fromJson(json['creator']));
  }
}
