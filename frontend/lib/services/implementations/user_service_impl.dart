import 'dart:convert';

import 'package:frontend/models/user.dart';
import 'package:frontend/requests/login_request.dart';
import 'package:frontend/requests/register_request.dart';
import 'package:frontend/response/response.dart';
import 'package:frontend/services/abstractions/user_service.dart';
import 'package:http/http.dart' as http;

class UserServiceImpl implements UserService {
  late final User currentUser;

  @override
  Future<Response<User>> login(LoginRequest request) async {
    try {
      var response =
          await http.post(Uri.parse("http://192.168.0.104:7012/api/user/login"),
              headers: <String, String>{
                'Content-Type': 'application/json; charset=UTF-8',
              },
              body: jsonEncode(request.toJson()));
      if (response.statusCode == 200) {
        Map<String, dynamic> decoded = jsonDecode(response.body);
        if (decoded.containsKey("errorCode")) {
          return Response(
              data: null,
              message: decoded['message'],
              errorCode: decoded['errorCode']);
        } else {
          currentUser = User.fromJson(decoded['data']);
          return Response(
              data: currentUser,
              message: decoded['message'] ?? "",
              errorCode: null);
        }
      } else {
        return Response(
            data: null,
            message: "Error during http request",
            errorCode: "E400");
      }
    } catch (e) {
      return Response(data: null, message: "Unknown error", errorCode: "E000");
    }
  }

  @override
  Future<Response<bool>> register(RegisterRequest request) async {
    try {
      var response = await http.post(
          Uri.parse("http://192.168.0.104:7012/api/user/register"),
          headers: <String, String>{
            'Content-Type': 'application/json; charset=UTF-8',
          },
          body: jsonEncode(request.toJson()));
      if (response.statusCode == 200) {
        Map<String, dynamic> decoded = jsonDecode(response.body);
        if (decoded.containsKey("errorCode")) {
          return Response(
              data: false,
              message: decoded['message'],
              errorCode: decoded['errorCode']);
        } else {
          return Response(
              data: true, message: decoded['message'] ?? "", errorCode: null);
        }
      } else {
        return Response(
            data: null,
            message: "Error during http request",
            errorCode: "E400");
      }
    } catch (e) {
      return Response(data: false, message: "Unknown error", errorCode: "E000");
    }
  }
}
