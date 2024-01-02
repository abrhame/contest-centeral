import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';

import '../../../../core/utils/colors.dart';

int touchedIndex = 0;
List<PieChartSectionData> showingSections() {
  return List.generate(2, (i) {
    final isTouched = i == touchedIndex;
    final fontSize = isTouched ? 20.0 : 16.0;
    final radius = isTouched ? 110.0 : 100.0;
    final widgetSize = isTouched ? 55.0 : 40.0;
    const shadows = [Shadow(color: Colors.black, blurRadius: 2)];

    switch (i) {
      case 0:
        return PieChartSectionData(
          color: const Color(0xffA3B3E5),
          value: 20,
          title: '20%',
          radius: radius,
          titleStyle: TextStyle(
            fontSize: fontSize,
            fontWeight: FontWeight.bold,
            color: const Color(0xffffffff),
            shadows: shadows,
          ),
        );
      case 1:
        return PieChartSectionData(
            color: AppColors.contentColorBlue,
            value: 80,
            title: '80%',
            radius: radius,
            titleStyle: TextStyle(
              fontSize: fontSize,
              fontWeight: FontWeight.bold,
              color: const Color(0xffffffff),
              shadows: shadows,
            ));

      default:
        throw Exception('Oh no');
    }
  });
}
