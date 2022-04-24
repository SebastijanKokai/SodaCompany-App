import test from "tape";

import { call, put } from "redux-saga/effects";

import OrderServices from "../../services/OrderServices";
import { handleGetOrders } from "./handlers/orders";

test("handle get orders test", (assert) => {
  const gen = handleGetOrders();

  assert.equal(gen.next().done, false);

  // assert.deepEqual(
  //   gen.next(),
  //   { done: false, value: call(OrderServices.getAll) },
  //   "handle get orders must call OrderServices get all function"
  // );

  // assert.deepEqual(
  //   gen.next(),
  //   { done: true, value: }
  // )
});
