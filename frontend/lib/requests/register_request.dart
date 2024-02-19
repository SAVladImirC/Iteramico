class RegisterRequest {
  final String firstName;
  final String lastName;
  final String email;
  final String phoneNumber;
  final String username;
  final String password;
  final String gender;

  RegisterRequest(
      {required this.firstName,
      required this.lastName,
      required this.email,
      required this.phoneNumber,
      required this.username,
      required this.password,
      required this.gender});

  Map<String, dynamic> toJson() {
    return {
      'firstName': firstName,
      'lastName': lastName,
      'email': email,
      'phoneNumber': phoneNumber,
      'username': username,
      'password': password,
      'gender': gender,
    };
  }
}
