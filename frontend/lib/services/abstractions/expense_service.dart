import 'package:frontend/models/expense.dart';
import 'package:frontend/requests/create_expense_request.dart';
import 'package:frontend/response/response.dart';

abstract class ExpenseService {
  Future<Response<List<Expense>>> getAllExpensesForJourney(int journeyId);
  Future<Response<Expense>> create(ExpenseCreateRequest request);
}
