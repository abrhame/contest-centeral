import 'package:flutter/material.dart';

Widget cardData(
    String title, String value, String buttonName, Function() onPressed) {
  return Padding(
    padding: const EdgeInsets.only(top: 10.0),
    child: Column(children: [
      Row(
        children: [
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                title,
                style: const TextStyle(
                  fontSize: 14,
                  fontWeight: FontWeight.bold,
                  color: Color.fromARGB(255, 107, 104, 104),
                ),
              ),
              Text(
                value,
                style: const TextStyle(
                  fontSize: 14,
                  color: Color.fromARGB(255, 107, 104, 104),
                ),
              ),
            ],
          ),
          const Spacer(),
          // small edit button
          GestureDetector(
            onTap: onPressed,
            child: Container(
                decoration: BoxDecoration(
                  color: const Color.fromARGB(255, 215, 224, 248),
                  borderRadius: BorderRadius.circular(15.0),
                ),
                child: Padding(
                  padding:
                      EdgeInsets.only(left: 24, right: 24, top: 5, bottom: 5),
                  child: Text(
                    buttonName,
                    style: TextStyle(
                      fontSize: 12,
                      color: Color.fromARGB(255, 46, 45, 45),
                    ),
                  ),
                )),
          ),
        ],
      ),
      Container(height: 10),
    ]),
  );
}
