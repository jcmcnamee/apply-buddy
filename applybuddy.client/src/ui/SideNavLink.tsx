import { ReactNode } from "react";
import { NavLink } from "react-router";

type SideNavLinkProps = {
  to: string;
  logo: ReactNode;
  children: ReactNode;
};

function SideNavLink({ to, logo, children }: SideNavLinkProps) {
  return (
    <NavLink
      to={to}
      className={"flex flex-row gap-1.5 btn-effects py-2 px-4 items-center"}
    >
      {logo}
      <span>{children}</span>
    </NavLink>
  );
}

export default SideNavLink;
