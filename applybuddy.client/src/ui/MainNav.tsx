import { LuLayoutDashboard, LuLayoutList } from "react-icons/lu";
import SideNavLink from "./SideNavLink";

function MainNav() {
  return (
    <nav>
      <ul className="flex flex-col gap-2">
        <li>
          <SideNavLink to="./dashboard" logo={<LuLayoutDashboard/>}>
            Dashboard
          </SideNavLink>
        </li>
        <li>
          <SideNavLink to="./applications" logo={<LuLayoutList/>}>
            Applications
          </SideNavLink>
        </li>
      </ul>
    </nav>
  );
}

export default MainNav;
