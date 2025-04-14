import { Outlet } from "react-router";
import Header from "./Header";
import Sidebar from "./Sidebar";

function AppLayout() {
  return (
    <div className="h-screen grid grid-cols-[26rem_1fr] grid-rows-[auto_1fr]">
      <Header />
      <Sidebar />
      <main className="bg-gray-50">
        <Outlet />
      </main>
    </div>
  );
}

export default AppLayout;
