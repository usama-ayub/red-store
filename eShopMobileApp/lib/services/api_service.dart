import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

/// Wrapper class for standard API responses
class ApiResponse<T> {
  final bool success;
  final T? data;
  final String? message;
  final int? statusCode;

  ApiResponse({
    required this.success,
    this.data,
    this.message,
    this.statusCode,
  });
}

class ApiService {
  static final ApiService _instance = ApiService._internal();
  factory ApiService() => _instance;
  ApiService._internal();

  String? token;
  final String _baseUrl = 'https://fakestoreapi.com';

  Future<String?> _getToken() async {
    if (token == null || token!.isEmpty) {
      final prefs = await SharedPreferences.getInstance();
      token = prefs.getString('token');
    }
    return token;
  }

  // ========================
  // ✅ GET Method
  // ========================
  Future<ApiResponse<dynamic>> get(String endpoint,
      {bool useToken = true}) async {
    try {
      final headers = await _buildHeaders(useToken);
      final url = Uri.parse('$_baseUrl$endpoint');
      final response = await http.get(url, headers: headers);
      return _handleResponse(response);
    } catch (e) {
      return _handleError(e);
    }
  }

  // ========================
  // ✅ POST Method
  // ========================
  Future<ApiResponse<dynamic>> post(
    String endpoint,
    Map<String, dynamic> data, {
    bool useToken = true,
  }) async {
    try {
      final headers = await _buildHeaders(useToken);
      final url = Uri.parse('$_baseUrl$endpoint');
      final response = await http.post(
        url,
        headers: headers,
        body: jsonEncode(data),
      );
      return _handleResponse(response);
    } catch (e) {
      return _handleError(e);
    }
  }

  // ✅ PUT Method
  Future<ApiResponse<dynamic>> put(
    String endpoint,
    Map<String, dynamic> data, {
    bool useToken = true,
  }) async {
    try {
      final headers = await _buildHeaders(useToken);
      final url = Uri.parse('$_baseUrl$endpoint');
      final response = await http.put(
        url,
        headers: headers,
        body: jsonEncode(data),
      );
      return _handleResponse(response);
    } catch (e) {
      return _handleError(e);
    }
  }

  // ✅ DELETE Method
  Future<ApiResponse<dynamic>> delete(String endpoint,
      {bool useToken = true}) async {
    try {
      final headers = await _buildHeaders(useToken);
      final url = Uri.parse('$_baseUrl$endpoint');
      final response = await http.delete(url, headers: headers);
      return _handleResponse(response);
    } catch (e) {
      return _handleError(e);
    }
  }

  // ========================
  // 🔐 Build Headers
  // ========================
  Future<Map<String, String>> _buildHeaders(bool useToken) async {
    final headers = {'Content-Type': 'application/json'};
    if (useToken) {
      final token = await _getToken();
      if (token != null && token.isNotEmpty) {
        headers['Authorization'] = 'Bearer $token';
      }
    }
    return headers;
  }

  // ========================
  // ✅ Response Handler
  // ========================
  ApiResponse<dynamic> _handleResponse(http.Response response) {
    final int statusCode = response.statusCode;
    try {
      final decoded = jsonDecode(response.body);

      if (statusCode >= 200 && statusCode < 300) {
        return ApiResponse(
          success: true,
          data: decoded,
          statusCode: statusCode,
        );
      } else {
        return ApiResponse(
          success: false,
          message: decoded['message'] ?? 'Something went wrong',
          statusCode: statusCode,
        );
      }
    } catch (e) {
      return ApiResponse(
        success: false,
        message: 'Invalid response format',
        statusCode: statusCode,
      );
    }
  }

  // ========================
  // ❌ Error Handler
  // ========================
  ApiResponse<dynamic> _handleError(dynamic error) {
    return ApiResponse(
      success: false,
      message: 'Network error: $error',
      statusCode: null,
    );
  }
}
