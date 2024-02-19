import 'package:flutter/material.dart';
import 'package:frontend/requests/register_request.dart';
import 'package:frontend/response/response.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/user_service_impl.dart';

class RegistrationScreen extends StatefulWidget {
  const RegistrationScreen({Key? key}) : super(key: key);

  @override
  _RegistrationScreenState createState() => _RegistrationScreenState();
}

class _RegistrationScreenState extends State<RegistrationScreen> {
  final _formKey = GlobalKey<FormState>();

  final _firstNameController = TextEditingController();
  final _lastNameController = TextEditingController();
  final _usernameController = TextEditingController();
  final _phoneNumberController = TextEditingController();
  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();
  final _confirmPasswordController = TextEditingController();

  String _selectedGender = 'S';
  String _message = '';
  bool isMessageError = false;

  @override
  Widget build(BuildContext context) {
    final userService = getIt<UserServiceImpl>();

    return Scaffold(
      appBar: AppBar(
        title: const Text('Registration'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Form(
          key: _formKey,
          child: SingleChildScrollView(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                TextFormField(
                  controller: _firstNameController,
                  decoration: const InputDecoration(labelText: 'First Name'),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Please enter your first name';
                    }
                    return null;
                  },
                ),
                TextFormField(
                  controller: _lastNameController,
                  decoration: const InputDecoration(labelText: 'Last Name'),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Please enter your last name';
                    }
                    return null;
                  },
                ),
                DropdownButtonFormField<String>(
                  value: _selectedGender,
                  onChanged: (newValue) {
                    setState(() {
                      _selectedGender = newValue!;
                    });
                  },
                  items: ['Select gender', 'Male', 'Female']
                      .map((gender) => DropdownMenuItem(
                            value: gender[0],
                            child: Text(gender),
                          ))
                      .toList(),
                  decoration: const InputDecoration(
                      labelText: 'Gender', hintText: 'Select Gender'),
                  validator: (value) {
                    if (value == 'S') {
                      return 'Please select your gender';
                    }
                    return null;
                  },
                ),
                TextFormField(
                  controller: _usernameController,
                  decoration: const InputDecoration(labelText: 'Username'),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Please enter your username';
                    }
                    return null;
                  },
                ),
                TextFormField(
                  controller: _phoneNumberController,
                  decoration: const InputDecoration(labelText: 'Phone number'),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Please enter your phone number';
                    }
                    return null;
                  },
                ),
                TextFormField(
                  controller: _emailController,
                  decoration: const InputDecoration(labelText: 'Email'),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Please enter your email';
                    }
                    return null;
                  },
                ),
                TextFormField(
                  controller: _passwordController,
                  obscureText: true,
                  decoration: const InputDecoration(labelText: 'Password'),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Please enter your email';
                    }
                    return null;
                  },
                ),
                TextFormField(
                  controller: _confirmPasswordController,
                  obscureText: true,
                  decoration:
                      const InputDecoration(labelText: 'Confirm password'),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Please confirm your password';
                    }
                    if (value != _passwordController.text) {
                      return 'Your password confirmation does not match with the initial password';
                    }
                    return null;
                  },
                ),
                const SizedBox(height: 12.0),
                Text(
                  _message,
                  style: isMessageError
                      ? const TextStyle(color: Colors.red)
                      : const TextStyle(color: Colors.green),
                ),
                const SizedBox(height: 12.0),
                ElevatedButton(
                  onPressed: () async {
                    if (_formKey.currentState!.validate()) {
                      RegisterRequest request = RegisterRequest(
                          firstName: _firstNameController.text,
                          lastName: _lastNameController.text,
                          email: _emailController.text,
                          phoneNumber: _phoneNumberController.text,
                          username: _usernameController.text,
                          password: _passwordController.text,
                          gender: _selectedGender);

                      Response response = await userService.register(request);

                      if (response.errorCode == null) {
                        isMessageError = false;
                        Future.delayed(const Duration(seconds: 5), () {
                          Navigator.of(context).pop();
                        });
                      } else {
                        isMessageError = true;
                      }
                      setState(() {
                        _message = response.message!;
                      });
                    }
                  },
                  child: const Text('Register'),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
