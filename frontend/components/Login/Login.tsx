import Link from "next/link";
import React from "react";
import LoginForm from "./LoginForm";

type LoginProps = {};

const Login: React.FC<LoginProps> = () => {
  return (
    <div
      className="
    flex gap-4 flex-col
    w-full bg-white border-2 rounded-md px-10 py-12"
    >
      <h2 className="text-3xl">Log in</h2>
      <LoginForm />
      <div className="w-full flex align-middle justify-center ">
        Create new account?{" "}
        <Link href={"/signup"} className="text-slate-400 cursor-pointer">
          Sign up
        </Link>
      </div>
    </div>
  );
};
export default Login;
