import 'package:flutter/material.dart';

Widget buildUserStanding(int rank, String name, String group, String solved) {
  return Container(
    padding: const EdgeInsets.all(8.0),
    child: Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            Container(
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10.0),
                border: Border.all(
                    color: const Color.fromARGB(255, 48, 52, 54), width: 1.0),
              ),
              child: Padding(
                padding: const EdgeInsets.only(
                    top: 7, right: 10, left: 10, bottom: 7),
                child: Text(
                  '$rank',
                  style: const TextStyle(
                      fontWeight: FontWeight.bold,
                      fontSize: 25,
                      color: Colors.white),
                ),
              ),
            ),
            const SizedBox(width: 10.0),
            Column(
              mainAxisAlignment: MainAxisAlignment.start,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  '$name',
                  style: const TextStyle(
                      fontWeight: FontWeight.bold,
                      fontSize: 15,
                      color: Colors.white),
                ),
                Text(
                  group,
                  style: const TextStyle(
                    fontStyle: FontStyle.italic,
                    fontSize: 12.0,
                    color: Colors.grey,
                  ),
                ),
                Text(
                  solved,
                  style: const TextStyle(
                    fontStyle: FontStyle.italic,
                    fontSize: 12.0,
                    color: Colors.grey,
                  ),
                ),
              ],
            ),
          ],
        ),
      ],
    ),
  );
}