workspace "AlifeDB"
	architecture "x86"
	startproject "GUI"

	configurations {
		"Debug",
		"Release"
	}

outputdir = "%{cfg.buildcfg}-%{cfg.system}-%{cfg.architecture}"

project "alifeDB"
	location "alifeDB"
	kind "SharedLib"
	language "C#"

	targetdir ("bin/" .. outputdir .. "/%{prj.name}")
	objdir ("bin-int/" .. outputdir .. "/%{prj.name}")

	links {
		"%{prj.name}/vendor/protobuf-net/protobuf.dll",
		"System.Xml"
	}

	files {
		"%{prj.name}/**.**",
		"%{prj.name}/**.**",
		"%{prj.name}/**.**",
		"%{prj.name}/**.**"
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
		"%{prj.name}/**.**",
		"%{prj.name}/**.**",
		"%{prj.name}/**.**",
		"%{prj.name}/**.**",
		"%{prj.name}/**.**"
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
		"%{prj.name}/**.**",
		"%{prj.name}/**.**",
		"%{prj.name}/**.**",
		"%{prj.name}/**.**"
	}

	filter "configurations:Debug"
		symbols "On"
	filter "configurations:Release"
		optimize "On"