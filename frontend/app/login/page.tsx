import Login from "@/components/Login/Login";
import React from "react";

type pageProps = {};

const page: React.FC<pageProps> = () => {
  return (
    <div
      className="
    flex items-center justify-center h-screen
    mx-auto w-full max-w-md
    "
    >
      <Login />
    </div>
  );
};
export default page;
