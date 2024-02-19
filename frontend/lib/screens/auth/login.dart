import 'package:flutter/material.dart';
import 'package:frontend/requests/login_request.dart';
import 'package:frontend/response/response.dart';
import 'package:frontend/screens/auth/registration.dart';
import 'package:frontend/screens/journey/journey.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/user_service_impl.dart';

class LoginScreen extends StatefulWidget {
  const LoginScreen({super.key});

  @override
  // ignore: library_private_types_in_public_api
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final _formKey = GlobalKey<FormState>();

  final _userService = getIt<UserServiceImpl>();

  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  String _errorMessage = "";

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('Login'),
        ),
        body: Form(
          key: _formKey,
          child: SingleChildScrollView(
              child: Column(
            children: [
              AspectRatio(
                aspectRatio: 16 / 9,
                child: Image.asset(
                  'assets/logo.png',
                  fit: BoxFit.contain, // Adjust the fit as needed
                ),
              ),
              Padding(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    TextFormField(
                      controller: _usernameController,
                      decoration:
                          const InputDecoration(labelText: 'Username or email'),
                      validator: (value) {
                        if (value == null || value.isEmpty) {
                          return 'Please enter your username or email';
                        }
                        return null;
                      },
                    ),
                    const SizedBox(height: 12.0),
                    TextFormField(
                      controller: _passwordController,
                      obscureText: true,
                      decoration: const InputDecoration(labelText: 'Password'),
                      validator: (value) {
                        if (value == null || value.isEmpty) {
                          return 'Please enter your password';
                        }
                        return null;
                      },
                    ),
                    const SizedBox(height: 12.0),
                    Text(
                      _errorMessage,
                      style: const TextStyle(color: Colors.red),
                    ),
                    const SizedBox(height: 12.0),
                    SizedBox(
                      width: double.infinity,
                      child: ElevatedButton(
                        onPressed: () async {
                          if (_formKey.currentState!.validate()) {
                            Response response = await _userService.login(
                                LoginRequest(
                                    usernameOrEmail: _usernameController.text,
                                    password: _passwordController.text));

                            if (response.errorCode == null) {
                              // ignore: use_build_context_synchronously
                              Navigator.pushReplacement(
                                context,
                                MaterialPageRoute(
                                    builder: (context) => const Journey()),
                              );
                            } else {
                              setState(() {
                                _errorMessage = response.message!;
                              });
                            }
                          }
                        },
                        child: const Text('Login'),
                      ),
                    ),
                    const SizedBox(height: 12.0),
                    GestureDetector(
                      onTap: () {
                        // Navigate to registration page
                        Navigator.push(
                          context,
                          MaterialPageRoute(
                              builder: (context) => const RegistrationScreen()),
                        );
                      },
                      child: const Text(
                        'No account? Register here!',
                        style: TextStyle(
                          color: Colors.blue,
                          decoration: TextDecoration.underline,
                        ),
                      ),
                    ),
                  ],
                ),
              )
            ],
          )),
        ));
  }
}
