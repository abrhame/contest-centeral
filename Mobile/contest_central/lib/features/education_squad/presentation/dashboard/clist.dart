import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class CLists extends StatefulWidget {
  final String rank;
  final String svgPath;
  final String name;
  final String percent;

  CLists({
    required this.rank,
    required this.svgPath,
    required this.name,
    required this.percent,
  });

  @override
  _ListsState createState() => _ListsState();
}

class _ListsState extends State<CLists> {
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(10),
      child: Row(
        children: [
          Container(
            color: const Color(0xffB6C6FE),
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
                width: MediaQuery.of(context).size.width * 0.75,
                height: 45,
                decoration: BoxDecoration(
                  border: Border.all(
                    color: const Color(0xffB6C6FE),
                    width: 1.0,
                  ),
                ),
                child: Padding(
                  padding: const EdgeInsets.all(8),
                  child: Row(
                    children: [
                      SvgPicture.string(widget.svgPath),
                      Align(
                        alignment: const Alignment(-0.2, 0),
                        child: Text(
                          widget.name,
                          style: const TextStyle(
                            fontSize: 15,
                            color: Colors.black,
                          ),
                          textAlign: TextAlign.center,
                        ),
                      ),
                    ],
                  ),
                ),
              ),
              Positioned(
                right: 0,
                bottom: 0,
                child: CustomPaint(
                  painter: ParallelogramPainter(
                    fillColor: const Color.fromARGB(255, 182, 198, 254),
                    borderColor: const Color.fromARGB(255, 182, 198, 254),
                  ),
                  child: Container(
                    width: 95,
                    height: 50,
                    child: Center(
                      child: Text(
                        widget.percent,
                        style: const TextStyle(
                          fontSize: 12,
                          color: Colors.black,
                        ),
                      ),
                    ),
                  ),
                ),
              ),
              Positioned(
                right: -77,
                bottom: 0,
                child: CustomPaint(
                  painter: ParallelogramPainter(
                    fillColor: const Color.fromARGB(255, 255, 255, 255),
                    borderColor: const Color.fromARGB(255, 255, 255, 255),
                  ),
                  child: Container(
                    width: 95,
                    height: 50,
                    child: const Center(
                      child: Text(
                        '',
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

  ParallelogramPainter({required this.fillColor, required this.borderColor});

  @override
  void paint(Canvas canvas, Size size) {
    Paint fillPaint = Paint()
      ..color = fillColor
      ..style = PaintingStyle.fill;

    Paint parallelogramBorderPaint = Paint()
      ..color = borderColor
      ..style = PaintingStyle.stroke
      ..strokeWidth = 2.0;

    Path parallelogramPath = Path()
      ..moveTo(20, 0)
      ..lineTo(size.width, 0)
      ..lineTo(size.width - 20, size.height)
      ..lineTo(0, size.height)
      ..close();

    canvas.drawPath(parallelogramPath, fillPaint);
    canvas.drawPath(parallelogramPath, parallelogramBorderPaint);
  }

  @override
  bool shouldRepaint(CustomPainter oldDelegate) {
    return false;
  }
}
