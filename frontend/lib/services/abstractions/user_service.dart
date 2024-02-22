import 'package:frontend/models/user.dart';
import 'package:frontend/requests/login_request.dart';
import 'package:frontend/requests/register_request.dart';
import 'package:frontend/response/response.dart';

abstract class UserService {
  Future<Response<User>> login(LoginRequest request);
  Future<Response<bool>> register(RegisterRequest request);
  Future<Response<List<User>>> getAllJourneyParticipants(int journeyId);
}
