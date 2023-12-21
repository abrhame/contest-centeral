import 'dart:ffi';

import 'package:flutter/material.dart';

import '../../../auth/presentation/screens/splash.dart';

class ESquadDashBoard extends StatefulWidget {
  const ESquadDashBoard({super.key, required this.user_id});

  final int user_id;

  @override
  State<ESquadDashBoard> createState() => _ESquadDashBoardState();
}

class _ESquadDashBoardState extends State<ESquadDashBoard> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        title: const Text("Contest Central"),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            ElevatedButton(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => SplashScreen(),
                  ),
                );
              },
              child: const Text("Home"),
            ),
          ],
        ),
      ),
    );
  }
}
