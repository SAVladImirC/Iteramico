class Response<T> {
  final T? data;
  final String? message;
  final String? errorCode;

  Response(
      {required this.data, required this.message, required this.errorCode});
}
