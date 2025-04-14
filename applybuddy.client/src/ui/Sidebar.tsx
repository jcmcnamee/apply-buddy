import Logo from "./Logo";
import MainNav from "./MainNav";

function Sidebar() {
  return (
    <aside className="bg-white py-4 px-2 border-1 border-gray-100 row-start-1 row-end-[-1]">
      <Logo />
      <MainNav />
    </aside>
  );
}

export default Sidebar;
