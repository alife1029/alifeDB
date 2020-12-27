workspace "AlifeDB"
	architecture "x86"
	startproject "GUI"

	configurations {
		"Debug",
		"Release"
	}

outputdir = "%{cfg.buildcfg}-%{cfg.system}-%{cfg.architecture}"
GUIoutputdir = "{COPY} %{cfg.buildtarget.relpath} ../bin/" .. outputdir .. "/GUI"
SandboxOutputdir = "{COPY} %{cfg.buildtarget.relpath} ../bin/" .. outputdir .. "/GUI"

project "alifeDB"
	location "alifeDB"
	kind "SharedLib"
	language "C#"

	targetdir ("bin/" .. outputdir .. "/%{prj.name}")
	objdir ("bin-int/" .. outputdir .. "/%{prj.name}")

	files {
		"%{prj.name}/**.cs",
		"%{prj.name}/**.xml",
		"%{prj.name}/**.resx",
		"%{prj.name}/**.config"
	}

	postbuildcommands {
		("{COPY} %{cfg.buildtarget.relpath} ../bin/" .. outputdir .. "/GUI"),
		("{COPY} %{cfg.buildtarget.relpath} ../bin/" .. outputdir .. "/Sandbox")
	}

	filter "configurations:Debug"
		symbols "On"
	filter "configurations:Release"
		optimize "On"

project "GUI"
	location "GUI"
	kind "WindowedApp"
	language "C#"
	links {
		"System", 
		"System.Windows.Forms", 
		"alifeDB",
		"System.Drawing",
		"System.Data"
	}

	targetdir ("bin/" .. outputdir .. "/%{prj.name}")
	objdir ("bin-int/" .. outputdir .. "/%{prj.name}")

	files {
		"%{prj.name}/**.cs",
		"%{prj.name}/**.xml",
		"%{prj.name}/**.png",
		"%{prj.name}/**.resx",
		"%{prj.name}/**.config"
	}

	filter "configurations:Debug"
		symbols "On"
	filter "configurations:Release"
		optimize "On"

project "Sandbox"
	location "Sandbox"
	kind "ConsoleApp"
	language "C#"
	links {
		"System",
		"alifeDB"
	}

	targetdir ("bin/" .. outputdir .. "/%{prj.name}")
	objdir ("bin-int/" .. outputdir .. "/%{prj.name}")

	files {
		"%{prj.name}/**.cs",
		"%{prj.name}/**.xml",
		"%{prj.name}/**.resx",
		"%{prj.name}/**.config"
	}

	filter "configurations:Debug"
		symbols "On"
	filter "configurations:Release"
		optimize "On"