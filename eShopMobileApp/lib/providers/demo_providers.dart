import 'dart:convert';
import 'dart:math';

import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:http/http.dart' as http;

final postProvider = FutureProvider<List<PostModel>>((ref) async {
  try {
    final response =
        await http.get(Uri.parse('https://jsonplaceholder.typicode.com/posts'));
    if (response.statusCode == 200) {
      final List<dynamic> data = jsonDecode(response.body);
      List<PostModel> postsList =
          data.map((e) => PostModel.fromJson(e)).toList();
      return postsList;
    } else {
      throw 'Something Wrong ${response.statusCode}';
    }
  } catch (e) {
    rethrow;
  }
});

class PostModel {
  final int id;
  final int userId;
  final String title;
  final String body;

  PostModel(
      {required this.id,
      required this.userId,
      required this.title,
      required this.body});

  factory PostModel.fromJson(Map<String, dynamic> json) {
    return PostModel(
      id: json['id'],
      userId: json['id'],
      title: json['title'],
      body: json['body'],
    );
  }
}

final stockPriceProvider = StreamProvider<double>((ref) async* {
  final random = Random();
  double currentPrice = 100.0;
  while (true) {
    await Future.delayed(const Duration(seconds: 1));
    currentPrice += random.nextDouble() * 4 - 2;
    yield double.parse(currentPrice.toStringAsFixed(2));
  }
});

// Paramater Provider with any provider of riverpod.
final increament = StateProvider.family<int, int>((ref, payload) {
  return 2;
});
