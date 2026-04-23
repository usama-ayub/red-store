import 'package:flutter/material.dart';
import 'package:helloworld/screens/constants.dart';
import 'package:helloworld/screens/login_screen.dart';
import 'package:helloworld/screens/main_screen.dart';

class RegisterScreen extends StatelessWidget {
  const RegisterScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Stack(
      children: [
        Positioned(
            top: -330,
            right: -330,
            child: Container(
              width: 600,
              height: 600,
              decoration: const BoxDecoration(
                  color: lightBlueColor, shape: BoxShape.circle),
            )),
        Positioned(
            top: -((1 / 4) * 500),
            right: -((1 / 4) * 500),
            child: Container(
              width: 450,
              height: 450,
              decoration: BoxDecoration(
                  shape: BoxShape.circle,
                  border: Border.all(color: lightBlueColor, width: 2)),
            )),
        Positioned(
          left: -280,
          bottom: -120,
          child: Container(
            width: 350,
            height: 340,
            decoration: BoxDecoration(
                border: Border.all(color: lightBlueColor, width: 2)),
          ),
        ),
        Positioned(
          left: -258,
          bottom: -120,
          child: Transform.rotate(
            angle: -0.99999,
            child: Container(
              width: 372,
              height: 250,
              decoration: BoxDecoration(
                  border: Border.all(color: lightBlueColor, width: 2)),
            ),
          ),
        ),
        Padding(
          padding: EdgeInsets.symmetric(horizontal: 22),
          child: Column(
            children: [
              SizedBox(height: 60),
              const Text(
                "Create Account",
                textAlign: TextAlign.center,
                style: heading02,
              ),
              SizedBox(height: 10),
              Padding(
                  padding: EdgeInsets.symmetric(horizontal: 40),
                  child: Text(
                    "Create an account so you can explore all the existing jobs",
                    textAlign: TextAlign.center,
                    style: TextStyle(fontSize: 12, color: blackColor),
                  )),
              SizedBox(height: 60),
              TextField(
                  decoration: InputDecoration(
                fillColor: lightBlueColor,
                filled: true,
                hintText: "Email",
                border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(10),
                    borderSide: BorderSide.none),
              )),
              SizedBox(height: 20),
              TextField(
                  decoration: InputDecoration(
                fillColor: lightBlueColor,
                filled: true,
                hintText: "Password",
                border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(10),
                    borderSide: BorderSide.none),
              )),
              SizedBox(height: 20),
              TextField(
                  decoration: InputDecoration(
                fillColor: lightBlueColor,
                filled: true,
                hintText: "Confirm Password",
                border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(10),
                    borderSide: BorderSide.none),
              )),
              SizedBox(height: 20),
              SizedBox(
                width: double.infinity,
                height: 60,
                child: ElevatedButton(
                  style: ElevatedButton.styleFrom(
                    backgroundColor: primaryColor,
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(10)),
                  ),
                  onPressed: () => {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (context) => const MainScreen()))
                  },
                  child: const Text(
                    "Sign Up",
                    style: TextStyle(fontSize: 20, color: whiteColor),
                  ),
                ),
              ),
              SizedBox(height: 15),
              InkWell(
                onTap: () {
                  Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => const LoginScreen()));
                },
                child: const Text(
                  "Already have an account",
                  style: TextStyle(fontSize: 15, fontWeight: FontWeight.w500),
                ),
              ),
              SizedBox(height: 40),
              const Text(
                "Or continue with",
                style: TextStyle(
                    color: primaryColor,
                    fontSize: 16,
                    fontWeight: FontWeight.w500),
              ),
              SizedBox(height: 10),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Container(
                    width: 60,
                    height: 44,
                    decoration: BoxDecoration(
                        color: Colors.grey.withOpacity(0.2),
                        borderRadius: BorderRadius.circular(10)),
                    child: Image.asset(
                      'assets/google.png',
                    ),
                  ),
                  SizedBox(
                    width: 10,
                  ),
                  Container(
                    width: 60,
                    height: 44,
                    decoration: BoxDecoration(
                        color: Colors.grey.withOpacity(0.2),
                        borderRadius: BorderRadius.circular(10)),
                    child: Image.asset('assets/facebook.png'),
                  ),
                  SizedBox(
                    width: 10,
                  ),
                  Container(
                    width: 60,
                    height: 44,
                    decoration: BoxDecoration(
                        color: Colors.grey.withOpacity(0.2),
                        borderRadius: BorderRadius.circular(10)),
                    child: Image.asset('assets/apple.png'),
                  )
                ],
              )
            ],
          ),
        )
      ],
    ));
  }
}
