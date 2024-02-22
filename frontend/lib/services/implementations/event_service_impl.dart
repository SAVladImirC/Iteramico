import 'dart:convert';

import 'package:frontend/models/event.dart';
import 'package:frontend/requests/event_create_request.dart';
import 'package:frontend/response/response.dart';
import 'package:frontend/services/abstractions/event_service.dart';

import 'package:http/http.dart' as http;

class EventServiceImpl implements EventService {
  final String baseUrl = "https://10.0.2.2";
  //final String baseUrl = "http://192.168.0.104";

  @override
  Future<Response<Event>> create(EventCreateRequest request) async {
    try {
      var response =
          await http.post(Uri.parse("$baseUrl:7012/api/event/create"),
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
          return Response(
              data: null, message: decoded['message'] ?? "", errorCode: null);
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
  Future<Response<List<Event>>> getAllEventsForJourney(int journeyId) async {
    try {
      var response = await http.get(
          Uri.parse("$baseUrl:7012/api/event/$journeyId"),
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
          List<Event> participations = decoded['data']
              .map<Event>((json) => Event.fromJson(json))
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
}
