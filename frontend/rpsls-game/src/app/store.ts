import { configureStore } from '@reduxjs/toolkit';
import { choiceApi, gameApi } from '../services';

export const store = configureStore({
  reducer: {
    [choiceApi.reducerPath]: choiceApi.reducer,
    [gameApi.reducerPath]: gameApi.reducer
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware()
      .concat(choiceApi.middleware)
      .concat(gameApi.middleware)
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
