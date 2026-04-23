import 'package:flutter/material.dart';
import 'package:helloworld/screens/constants.dart';

class SplashScreen extends StatelessWidget {
  const SplashScreen({super.key});
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
          color: primaryColor.withOpacity(0.7),
          child: Center(
            child: Image.asset(
              'assets/logo.png',
            ),
          )),
    );
  }
}
