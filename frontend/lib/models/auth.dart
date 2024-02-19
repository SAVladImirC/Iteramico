class Auth {
  final String username;
  final int loginAttempts;

  Auth({required this.username, required this.loginAttempts});

  factory Auth.fromJson(Map<String, dynamic> json) {
    return Auth(
        username: json['username'], loginAttempts: json['loginAttempts'] ?? 0);
  }
}
