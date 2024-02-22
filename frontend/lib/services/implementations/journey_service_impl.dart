import 'dart:convert';

import 'package:frontend/models/journey.dart';
import 'package:frontend/models/journey_participation.dart';
import 'package:frontend/response/response.dart';
import 'package:frontend/services/abstractions/journey_service.dart';

import 'package:http/http.dart' as http;

class JourneyServiceImpl implements JourneyService {
  @override
  Future<Response<List<JourneyParticipation>>> getAllJourneysForUser(
      int userId) async {
    try {
      var response = await http.get(
          Uri.parse("https://10.0.2.2:7012/api/journey/by-user/$userId"),
          headers: <String, String>{
            'Content-Type': 'application/json; charset=UTF-8',
          });
      if (response.statusCode == 200) {
        Map<String, dynamic> decoded = jsonDecode(response.body);
        if (decoded.containsKey("errorCode")) {
          return Response(
              data: null,
              message: decoded['message'],
              errorCode: decoded['errorCode']);
        } else {
          List<JourneyParticipation> participations = decoded['data']
              .map<JourneyParticipation>(
                  (json) => JourneyParticipation.fromJson(json))
              .toList();
          return Response(
              data: participations,
              errorCode: null,
              message: decoded['message']);
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
  Future<Response<Journey>> getJourneyById(int id) async {
    try {
      var response = await http.get(
          Uri.parse("https://10.0.2.2:7012/api/journey/by-id/$id"),
          headers: <String, String>{
            'Content-Type': 'application/json; charset=UTF-8',
          });
      if (response.statusCode == 200) {
        Map<String, dynamic> decoded = jsonDecode(response.body);
        if (decoded.containsKey("errorCode")) {
          return Response(
              data: null,
              message: decoded['message'],
              errorCode: decoded['errorCode']);
        } else {
          Journey journey = Journey.fromJson(decoded['data']);
          return Response(
              data: journey, errorCode: null, message: decoded['message']);
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
}
