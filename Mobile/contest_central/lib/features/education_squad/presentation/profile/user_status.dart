import 'package:flutter/material.dart';

class StatusData extends StatefulWidget {
  StatusData();

  @override
  StatusDataState createState() => StatusDataState();
}

class StatusDataState extends State<StatusData> {
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.only(top: 10.0),
      child: Container(
        decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.circular(8.0),
          border: Border.all(
            color: const Color.fromARGB(91, 207, 207, 207),
            width: 1,
          ),
          boxShadow: const [
            BoxShadow(
              color: Color.fromRGBO(149, 157, 165, 0.26),
              offset: Offset(0, 8),
              blurRadius: 6.0,
            ),
          ],
        ),
        child: Column(children: [
          const Padding(
            padding: EdgeInsets.all(8.0),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  "Status",
                  style: TextStyle(
                    fontSize: 14,
                    fontWeight: FontWeight.bold,
                    color: Color.fromARGB(255, 107, 104, 104),
                  ),
                ),
              ],
            ),
          ),
          Container(height: 10),
        ]),
      ),
    );
  }
}
