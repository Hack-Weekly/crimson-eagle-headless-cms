import { configureStore } from "@reduxjs/toolkit";
import AuthSlice from "../features/auth/AuthSlice";
import ThemeSlice from "../features/theme/ThemeSlice";

export const store = configureStore({
  reducer: {
    Auth: AuthSlice,
    Theme: ThemeSlice,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
