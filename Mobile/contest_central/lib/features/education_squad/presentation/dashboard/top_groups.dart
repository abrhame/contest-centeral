import 'package:flutter/material.dart';

import 'list.dart';

class TopGroups extends StatefulWidget {
  final List<Map<dynamic, dynamic>> getRankedGroupsData;

  const TopGroups({super.key, required this.getRankedGroupsData});
  @override
  _TopGroupsState createState() => _TopGroupsState();
}

class _TopGroupsState extends State<TopGroups> {
  @override
  Widget build(BuildContext context) {
    return Center(
      child: Padding(
        padding: const EdgeInsets.only(left: 10, right: 10, top: 20),
        child: Container(
          decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: BorderRadius.circular(8.0),
            boxShadow: const [
              BoxShadow(
                color: Color.fromRGBO(149, 157, 165, 0.2),
                offset: Offset(0, 8),
                blurRadius: 24.0,
              ),
            ],
          ),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.center,
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Padding(
                    padding: const EdgeInsets.all(5.0),
                    child: Container(
                      decoration: const BoxDecoration(
                        shape: BoxShape.circle,
                        color: Color(0xffFFDE9B),
                        boxShadow: [
                          BoxShadow(
                            color: Colors.black12,
                            blurRadius: 1,
                            offset: Offset(0, 4),
                          ),
                        ],
                      ),
                      padding: const EdgeInsets.all(8),
                      child: const Icon(Icons.groups,
                          color: Color.fromARGB(189, 31, 31, 31)),
                    ),
                  ),
                  const Text(
                    "Top Groups",
                    style: TextStyle(
                        fontSize: 20,
                        color: Color.fromARGB(255, 104, 101, 101)),
                  ),
                ],
              ),
              // Use ListView.builder to dynamically generate the list
              ListView.builder(
                shrinkWrap: true,
                itemCount: widget.getRankedGroupsData.length,
                itemBuilder: (context, index) {
                  final groupData = widget.getRankedGroupsData[index];
                  return InkWell(
                    onTap: () {
                      // Show a dialog with detailed information
                      _showGroupDetailDialog(context, groupData);
                    },
                    child: Lists(
                      rank: groupData['rank'].toString(),
                      group: groupData['name'],
                      percent: "80%",
                    ),
                  );
                },
              ),
            ],
          ),
        ),
      ),
    );
  }

  void _showGroupDetailDialog(
      BuildContext context, Map<dynamic, dynamic> groupData) {
    showDialog(
      context: context,
      builder: (context) {
        return Dialog(
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(16),
          ),
          child: Container(
            height: MediaQuery.of(context).size.height * 0.4,
            padding: const EdgeInsets.all(16),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                const Text(
                  "Group Details",
                  style: TextStyle(
                    fontSize: 18,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                const SizedBox(height: 10),
                _buildDetailRow("Group Name", groupData['name']),
                _buildDetailRow("Abbreviation", groupData['abbreviation']),
                _buildDetailRow("Generation", groupData['generation']),
                _buildDetailRow("Year", groupData['year']),
                _buildDetailRow("Location", groupData['location']['location']),
                _buildDetailRow("Number Of Problems Solved",
                    groupData['numberOfProblemsSolved'].toString()),
                const Spacer(),
                Align(
                  alignment: Alignment.center,
                  child: TextButton(
                    onPressed: () {
                      Navigator.of(context).pop();
                    },
                    child: const Text("Close"),
                  ),
                ),
              ],
            ),
          ),
        );
      },
    );
  }

  Widget _buildDetailRow(String label, String value) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 4),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Text(
            label,
            style: const TextStyle(
              fontWeight: FontWeight.bold,
            ),
          ),
          Text(value),
        ],
      ),
    );
  }
}
