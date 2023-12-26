import 'dart:math';
import 'package:flutter/material.dart';

class Lists extends StatefulWidget {
  final String rank;
  final String group;
  final String percent;
  Lists({
    required this.rank,
    required this.group,
    required this.percent,
  });
  @override
  _ListsState createState() => _ListsState();
}

class _ListsState extends State<Lists> {
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(10),
      child: Row(
        children: [
          Container(
            color: const Color(0xffFFDE9B),
            margin: const EdgeInsets.all(8),
            width: 30,
            height: 40,
            child: Padding(
              padding: const EdgeInsets.all(8),
              child: Text(
                widget.rank,
                style: const TextStyle(
                  fontSize: 15,
                  color: Colors.black,
                ),
              ),
            ),
          ),
          Stack(
            children: [
              Container(
                // width with media query
                width: MediaQuery.of(context).size.width * 0.75,
                height: 45,
                decoration: BoxDecoration(
                  border: Border.all(
                    color: const Color(0xffFFDE9B),
                    width: 1.0,
                  ),
                ),
                child: Padding(
                  padding: const EdgeInsets.all(8),
                  child: Align(
                    alignment: const Alignment(-0.4, 0),
                    child: Text(
                      widget.group,
                      style: const TextStyle(
                        fontSize: 16,
                        color: Colors.black,
                      ),
                      textAlign: TextAlign.center,
                    ),
                  ),
                ),
              ),
              Positioned(
                right: 0, // Adjusted right value for more space
                bottom: 0,
                child: CustomPaint(
                  painter: ParallelogramPainter(
                    fillColor: const Color.fromARGB(255, 255, 222, 155),
                    borderColor: const Color.fromARGB(255, 255, 222, 155),
                  ),
                  child: SizedBox(
                    width: 95,
                    height: 50,
                    child: Center(
                      child: Text(
                        widget.percent,
                        style: const TextStyle(
                          fontSize: 15,
                          color: Colors.black,
                        ),
                      ),
                    ),
                  ),
                ),
              ),
              Positioned(
                right: -77, // Adjusted right value for more space
                bottom: 0,
                child: CustomPaint(
                  painter: ParallelogramPainter(
                    fillColor: Colors.white,
                    borderColor: Colors.white,
                  ),
                  child: SizedBox(
                    width: 95,
                    height: 50,
                    child: const Center(
                      child: Text(
                        '', // Add content for the new parallelogram
                        style: TextStyle(
                          fontSize: 12,
                          color: Colors.black,
                        ),
                      ),
                    ),
                  ),
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }
}

class ParallelogramPainter extends CustomPainter {
  final Color fillColor;
  final Color borderColor;

  ParallelogramPainter({
    required this.fillColor,
    required this.borderColor,
  });

  @override
  void paint(Canvas canvas, Size size) {
    Paint fillPaint = Paint()
      ..color = fillColor
      ..style = PaintingStyle.fill;

    Paint borderPaint = Paint()
      ..color = borderColor
      ..style = PaintingStyle.stroke
      ..strokeWidth = 2.0;

    Path path = Path()
      ..moveTo(0, 0)
      ..lineTo(size.width - 20, 0)
      ..lineTo(size.width, size.height)
      ..lineTo(20, size.height)
      ..close();

    canvas.drawPath(path, fillPaint);
    canvas.drawPath(path, borderPaint);
  }

  @override
  bool shouldRepaint(CustomPainter oldDelegate) {
    return false;
  }
}
