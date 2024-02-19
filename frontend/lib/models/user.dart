import 'package:frontend/models/auth.dart';

class User {
  final int id;
  final String firstName;
  final String lastName;
  final String email;
  final String gender;
  final DateTime registeredOn;
  final Auth auth;

  User(
      {required this.id,
      required this.firstName,
      required this.lastName,
      required this.email,
      required this.registeredOn,
      required this.gender,
      required this.auth});

  factory User.fromJson(Map<String, dynamic> json) {
    return User(
      id: json['id'],
      firstName: json['firstName'],
      lastName: json['lastName'],
      email: json['email'],
      gender: json['gender'],
      registeredOn: DateTime.parse(json['registeredOn']),
      auth: Auth.fromJson(json['auth']),
    );
  }
}
