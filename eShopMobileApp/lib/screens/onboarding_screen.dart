import 'package:flutter/material.dart';
import 'package:helloworld/screens/constants.dart';
import 'package:helloworld/screens/login_screen.dart';
import 'package:helloworld/screens/register_screen.dart';

class OnBoardingScreen extends StatelessWidget {
  const OnBoardingScreen({super.key});

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
          padding: const EdgeInsets.symmetric(horizontal: 22),
          child: Column(
            children: [
              const SizedBox(
                height: 20,
              ),
              Image.asset('assets/illustration.png',
                  fit: BoxFit.cover, height: 350, width: 350),
              const Padding(
                  padding: EdgeInsets.symmetric(horizontal: 10),
                  child: Text(
                    "Discover Your Dream Job here",
                    textAlign: TextAlign.center,
                    style: heading01,
                  )),
              const SizedBox(
                height: 5,
              ),
              const Text(
                "Explore all the existing job roles based on your interest and study major",
                textAlign: TextAlign.center,
              ),
              const SizedBox(
                height: 10,
              ),
              Row(
                children: [
                  SizedBox(
                    width: 140,
                    height: 60,
                    child: ElevatedButton(
                      style: ElevatedButton.styleFrom(
                          backgroundColor: primaryColor,
                          shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(10))),
                      onPressed: () => {
                        Navigator.push(
                            context,
                            MaterialPageRoute(
                                builder: (context) => const LoginScreen()))
                      },
                      child: const Text(
                        "Loginsss",
                        style: TextStyle(fontSize: 20, color: whiteColor),
                      ),
                    ),
                  ),
                  const SizedBox(width: 10),
                  SizedBox(
                    width: 140,
                    height: 60,
                    child: ElevatedButton(
                      style: ElevatedButton.styleFrom(
                        backgroundColor: whiteColor,
                        shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(10)),
                      ),
                      onPressed: () => {
                        Navigator.push(
                            context,
                            MaterialPageRoute(
                                builder: (context) => const RegisterScreen()))
                      },
                      child: const Text(
                        "Register",
                        style: TextStyle(fontSize: 20, color: primaryColor),
                      ),
                    ),
                  ),
                ],
              )
            ],
          ),
        )
      ],
    ));
  }
}
