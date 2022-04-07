import { createStore, applyMiddleware } from "redux";
import createSagaMiddleware from "@redux-saga/core";
import { helloSaga } from "./sagas";

const sagaMiddleware = createSagaMiddleware();

const store = createStore();
