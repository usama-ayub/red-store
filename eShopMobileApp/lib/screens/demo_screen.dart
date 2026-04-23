import 'dart:js';

import 'package:flutter/material.dart';

import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:helloworld/providers/demo_providers.dart';

class DemoScreen extends ConsumerWidget {
  const DemoScreen({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    // final postList = ref.watch(postProvider);
    return Scaffold(
        appBar: AppBar(
          title: const Text('Get Api demo project'),
        ),
        body: Consumer(
          builder: (context, ref, child) {
            final stockPrice = ref.watch(stockPriceProvider);
            return Center(
              child: stockPrice.when(
                skipLoadingOnRefresh: false,
                data: (price) => Text(price.toString()),
                loading: () =>
                    const CircularProgressIndicator(), // ListView.builder,
                error: (error, stack) => Text('Error:$error'),

                // child: postList.when(
                //     skipLoadingOnRefresh: false,
                //     data: (data) => ListView.builder(
                //           itemCount: data.length,
                //           itemBuilder: (context, index) {
                //             final item = data[index];
                //             return Card(
                //               child: ListTile(
                //                 title: Text(item.title),
                //                 subtitle: Text(item.body),
                //               ), // ListTile
                //             ); // Card
                //           },
                //         ), // ListView.builder,
                //     error: (error, stack) => TextButton(
                //         onPressed: () {
                //           ref.invalidate(postProvider);
                //         },
                //         child: Text('Error:$error')),
                //     loading: () => const CircularProgressIndicator())
              ),
            );
          },
        )
        // AppBar
        ); // Scaffold
  }
}
